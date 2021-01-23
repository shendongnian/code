        private void CalculateExtendedDiskUsage(IEnumerable<Configuration> allConfigurations)
        {
            var sw = new Stopwatch();
            sw.Start();
            using (var ctx = new LocalEntities())
            {
                Debug.WriteLine("Context: " + sw.Elapsed);
                var allBuilds = ctx.Builds;
                var ruleResult = GetRulesResult(sw, allConfigurations, allBuilds); // Clean Code!!!
                // find owners and insert...
            }
        }
        private static IEnumerable<Notification> GetRulesResult(Stopwatch sw, IEnumerable<Configuration> allConfigurations, ICollection<Configuration> allBuilds)
        {
            // Lets take only confs that have been updated within last 7 days
            var ruleResult = allConfigurations
                .AsParallel() // Check if you really need this right here...
                .Where(IsConfigElegible) // Clean Code!!!
                .SelectMany(x => CreateNotifications(sw, allBuilds, x))
                .ToArray();
            Debug.WriteLine("Finished loop: " + sw.Elapsed);
            return ruleResult;
        }
        private static bool IsConfigElegible(Configuration x)
        {
            return x.artifact_cleanup_type != null &&
                   x.build_cleanup_type != null &&
                   x.updated_date > DateTime.UtcNow.AddDays(-7);
        }
        private static IEnumerable<Notification> CreateNotifications(Stopwatch sw, IEnumerable<Configuration> allBuilds, Configuration configuration)
        {
            // all builds for current configuration
            var configurationBuilds = allBuilds
                .Where(x => x.configuration_id == configuration.configuration_id);
            // .OrderByDescending(z => z.build_date); <<< You should order only when needed (most at the end)
            Debug.WriteLine("Filter conf builds: " + sw.Elapsed);
            configurationBuilds = BuildCleanup(configuration, configurationBuilds);    // Clean Code!!!
            configurationBuilds = ArtifactCleanup(configuration, configurationBuilds); // Clean Code!!!
            Debug.WriteLine("Done cleanup: " + sw.Elapsed);
            const int maxDiscAllocationPerConfiguration = 1000000000; // 1GB
            // Sum all disc usage per configuration
            var confDiscSizePerConfiguration = configurationBuilds
                .OrderByDescending(z => z.build_date) // I think that you can put this even later (or not to have anyway)
                .GroupBy(c => c.configuration_id) // No need to create a new object, just use the property
                .Where(c => (c.Sum(z => z.artifact_dir_size) > maxDiscAllocationPerConfiguration))
                .Select(CreateSumPerConfiguration);
            Debug.WriteLine("Done db query: " + sw.Elapsed);
            // Extracting to variable to be able to return it as function result
            var notifications = confDiscSizePerConfiguration
                .Select(CreateNotification);
            return notifications;
        }
        private static IEnumerable<Configuration> BuildCleanup(Configuration configuration, IEnumerable<Configuration> builds)
        {
            // Since I don't know which builds/artifacts have been cleaned up, calculate it manually
            if (configuration.build_cleanup_count == null) return builds;
            const int buildCleanupCount = 30; // Why 'string' if you always need as integer?
            builds = GetDiscartBelow(configuration, buildCleanupCount, builds); // Clean Code (almost)
            builds = GetDiscartAbove(configuration, buildCleanupCount, builds); // Clean Code (almost)
            return builds;
        }
        private static IEnumerable<Configuration> ArtifactCleanup(Configuration configuration, IEnumerable<Configuration> configurationBuilds)
        {
            if (configuration.artifact_cleanup_count != null)
            {
                // skipped, similar to previous block
            }
            return configurationBuilds;
        }
        private static SumPerConfiguration CreateSumPerConfiguration(IGrouping<object, Configuration> groupedBuilds)
        {
            var configuration = groupedBuilds.First();
            return new SumPerConfiguration
            {
                configurationId = configuration.configuration_id,
                configurationPath = configuration.configuration_path,
                Total = groupedBuilds.Sum(c => c.artifact_dir_size),
                Average = groupedBuilds.Average(c => c.artifact_dir_size)
            };
        }
        private static IEnumerable<Configuration> GetDiscartBelow(Configuration configuration,
            int buildCleanupCount,
            IEnumerable<Configuration> configurationBuilds)
        {
            if (!configuration.build_cleanup_type.Equals("ReserveBuildsByDays"))
                return configurationBuilds;
            var buildLastCleanupDate = DateTime.UtcNow.AddDays(-buildCleanupCount);
            var result = configurationBuilds
                .Where(x => x.build_date > buildLastCleanupDate);
            return result;
        }
        private static IEnumerable<Configuration> GetDiscartAbove(Configuration configuration,
            int buildLastCleanupCount,
            IEnumerable<Configuration> configurationBuilds)
        {
            if (!configuration.build_cleanup_type.Equals("ReserveBuildsByCount"))
                return configurationBuilds;
            var result = configurationBuilds
                .Take(buildLastCleanupCount);
            return result;
        }
        private static Notification CreateNotification(SumPerConfiguration iter)
        {
            return new Notification
            {
                ConfigurationId = iter.configurationId,
                CreatedDate = DateTime.UtcNow,
                RuleType = (int)RulesEnum.TooMuchDisc,
                ConfigrationPath = iter.configurationPath
            };
        }
    }
    internal class SumPerConfiguration {
        public object configurationId { get; set; }   //
        public object configurationPath { get; set; } // I did use 'object' cause I don't know your type data
        public int Total { get; set; }
        public double Average { get; set; }
    }
