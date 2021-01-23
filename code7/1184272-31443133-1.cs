    using System;
    using System.Collections;
    using System.Diagnostics;
    using System.Reflection;
    using NLog.Filters;
    using NLog.Targets;
    using NLog.Internal;
    namespace NLog
    {
    internal sealed class LoggerImpl
    {
        private LoggerImpl() { }
        private const int STACK_TRACE_SKIP_METHODS = 0;
        private static Assembly nlogAssembly = typeof(Logger).Assembly;
        internal static void Write(Type loggerType, TargetWithFilterChain targets, LogEventInfo logEvent, LogFactory factory)
        {
            if (targets == null)
                return;
    #if !NETCF            
            bool needTrace = false;
            bool needTraceSources = false;
            int nst = targets.NeedsStackTrace;
            if (nst > 0)
                needTrace = true;
            if (nst > 1)
                needTraceSources = true;
            StackTrace stackTrace = null;
            if (needTrace && !logEvent.HasStackTrace)
            {
                int firstUserFrame = 0;
                stackTrace = new StackTrace(STACK_TRACE_SKIP_METHODS, needTraceSources);
                for (int i = 0; i < stackTrace.FrameCount; ++i)
                {
                    System.Reflection.MethodBase mb = stackTrace.GetFrame(i).GetMethod();
                    if (mb.DeclaringType.Assembly == nlogAssembly || mb.DeclaringType == loggerType)
                    {
                        firstUserFrame = i + 1;
                    }
                    else
                    {
                        if (firstUserFrame != 0)
                            break;
                    }
                }
                logEvent.SetStackTrace(stackTrace, firstUserFrame);
            }
    #endif 
            for (TargetWithFilterChain awf = targets; awf != null; awf = awf.Next)
            {
                Target app = awf.Target;
                FilterResult result = FilterResult.Neutral;
                try
                {
                    FilterCollection filterChain = awf.FilterChain;
                    for (int i = 0; i < filterChain.Count; ++i)
                    {
                        Filter f = filterChain[i];
                        result = f.Check(logEvent);
                        if (result != FilterResult.Neutral)
                            break;
                    }
                    if ((result == FilterResult.Ignore) || (result == FilterResult.IgnoreFinal))
                    {
                        if (InternalLogger.IsDebugEnabled)
                        {
                            InternalLogger.Debug("{0}.{1} Rejecting message because of a filter.", logEvent.LoggerName, logEvent.Level);
                        }
                        if (result == FilterResult.IgnoreFinal)
                            return;
                        continue;
                    }
                }
                catch (Exception ex)
                {
                    InternalLogger.Error("FilterChain exception: {0}", ex);
                    if (factory.ThrowExceptions)
                        throw;
                    else
                        continue;
                }
                try
                {
                    app.Write(logEvent);
                }
                catch (Exception ex)
                {
                    InternalLogger.Error("Target exception: {0}", ex);
                    if (factory.ThrowExceptions)
                        throw;
                    else
                        continue;
                }
                if (result == FilterResult.LogFinal)
                    return;
            }
        }
    }
    }
