        public static DateTimeOffset GetLastApplicationBuildDateFromAssembly()
        {
            int gmtOfBuild = 1; //as the date/time is of the local machine where it was built, in my case +1 gmt
            var executingAssembly = Assembly.GetCallingAssembly();
            var executingAssemblyName = executingAssembly.GetName();
            var version = executingAssemblyName.Version;
            DateTimeOffset relativeDate = new DateTimeOffset(2000, 1, 1, 0, 0, 0, new TimeSpan(gmtOfBuild , 0, 0));
            int daysAfter1stJan2000 = version.Build;
            int secondsdAfterMidnight = version.MinorRevision * 2;
            var buildDate = relativeDate.AddDays(daysAfter1stJan2000).AddSeconds(secondsdAfterMidnight);
            return buildDate;
        }
