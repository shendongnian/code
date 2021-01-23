    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows.Documents;
    using System.Threading;
    using System.Collections.Concurrent;
    using System.Threading.Tasks;
    namespace PerformanceTest
    {
        public class Bridge
        {
            int counterLimit;
            public BlockingCollection<string> output;
            public BlockingCollection<string> impOutput;
            public BlockingCollection<string> errors;
            public BlockingCollection<string> impErrors;
            public BlockingCollection<string> logs;
            protected static Bridge controller = new Bridge();
            public static Bridge Controller
            {
                get
                {
                    return controller;
                }
            }
            public MainWindow Window
            {
                set
                {
                    if (value != null)
                    {
                        output = value.outputProducer;
                        impOutput = value.impOutputProducer;
                        errors = value.errorProducer;
                        impErrors = value.impErrorProducer;
                        logs = value.logsProducer;
                    }
                }
            }
            public bool Running
            {
                get;
                set;
            }
            private Bridge()
            {
                //20000 lines seems to slow down tabbing enough to prove my point.
                //increase this number to get even worse results.
                counterLimit = 40000;
            }
            public void PrintLotsOfText()
            {
                Task.Run(() => GenerateOutput());
                Task.Run(() => GenerateError());
            }
            private void GenerateOutput()
            {
                //There is tons of output text, so print super fast if possible.
                int counter = 1;
                while (Running && counter < counterLimit)
                {
                    PrintOutput("I will never say this horrible word again as long I live. This is confession #" + counter++ + ".");
                    //Task.Delay(1).Wait();
                }
            }
            private void GenerateError()
            {
                int counter = 1;
                while (Running && counter < counterLimit)
                {
                    PrintError("I will never forgive your errors as long I live. This is confession #" + counter++ + ".");
                    //Task.Delay(1).Wait();
                }
            }
            #region Printing
            delegate void StringArgDelegate(String s);
            delegate void InlineArgDelegate(Inline inline);
            public void PrintOutput(String s)
            {
                output.TryAdd(s);
                PrintLog("d " + s);
            }
            public void PrintImportantOutput(String s)
            {
                impOutput.TryAdd(s);
                PrintLog("D " + s);
            }
            public void PrintError(String s)
            {
                errors.TryAdd(s);
                PrintLog("e " + s);
            }
            public void PrintImportantError(String s)
            {
                impErrors.TryAdd(s);
                PrintLog("E " + s);
            }
            public void PrintLog(String s)
            {
                String text = s;
                logs.TryAdd(text);
            }
            #endregion
        }
    }
