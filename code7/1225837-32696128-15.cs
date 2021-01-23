        private static void ShowJobs(IScheduler sched, ILogger logger)
        {
            Console.WriteLine("");
            Console.WriteLine("ShowJobs : Start");
            GroupMatcher<JobKey> matcherAll = GroupMatcher<JobKey>.AnyGroup();
            Quartz.Collection.ISet<JobKey> jobKeys = sched.GetJobKeys(matcherAll);
            foreach (JobKey jk in jobKeys)
            {
                Console.WriteLine(string.Format("{0} : {1}", jk.Group, jk.Name));
                IJobDetail jobData = sched.GetJobDetail(jk);
                if (null != jobData)
                {
                    Console.WriteLine(string.Format("{0}", jobData.JobType.AssemblyQualifiedName));
                }
            }
            Console.WriteLine("ShowJobs : End");
            Console.WriteLine("");
        }
        private static void ReportIInterruptableJobs()
        {
            Type typ = typeof(IInterruptableJob);
            ICollection<Type> types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => typ.IsAssignableFrom(p)).ToList();
            if (null != types)
            {
                foreach (Type t in types)
                {
                    Console.WriteLine(string.Format("{0}", t.AssemblyQualifiedName));
                }
            }
        }
