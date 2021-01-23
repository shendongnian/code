    using System;
    using Microsoft.VisualStudio.TestTools.LoadTesting;
    
    namespace VerificationLoadTest
    {
        public class ContextParameterLoadTestPlugin : ILoadTestPlugin
        {
            LoadTest LoadTest;
            public void Initialize(LoadTest loadTest)
            {
                this.LoadTest = loadTest;
                this.LoadTest.TestStarting += new EventHandler<TestStartingEventArgs>(TestStarting);
            }
    
            void TestStarting(object sender, TestStartingEventArgs e)
            {
                foreach (string key in LoadTest.Context.Keys)
                {
                    e.TestContextProperties.Add(key, LoadTest.Context[key]);
                }
            }               
        }
    } 
