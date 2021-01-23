     public class MailProcessorExecutor
     {
         public MailProcessorSelector(IEnumerable<IProcessMail> processors)
         {
               _processors=processors;
         }
         public MailResult GetResult(Mail mail)
         {
             var proc=_processor.FirstOrDefault(p=>p.CanProcess(mail.MailType));
             if (proc==null)
             {
                 //throw something
             }
             return proc.GetMailResult(mail);
         }
        
        static IProcessMail[] _procCache=new IProcessMail[0];
         public static void AutoScanForProcessors(Assembly[] asms)
         {
           _procCache= asms.SelectMany(a=>a.GetTypesDerivedFrom<IProcessMail>()).Select(t=>Activator.CreateInstance(t)).ToArray();
         }
         public static MailProcessorExecutor CreateInstance()
         {
            return new MailProcessorExecutor(_procCache);
         }
      }
     
      //in startup/config 
      MailProcessorExecutor.AutoScanForProcessors([assembly containing the concrete types]);
     //usage
     var mailProc=MailProcessorExecutor.CreateInstance();
    var result=mailProc.GetResult(mail);
     
