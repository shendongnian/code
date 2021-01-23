       protected override void Seed(MyDbContext context)
        {
            //  This method will be called after migrating to the latest version.
            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            UpgradeVersion(context, 100, null);
            UpgradeVersion(context, 101, (ver) => { /*do upgrade actions to version 101 */ });
            UpgradeVersion(context, 102, (ver) => { /*do upgrade actions to version 102 */ });
        }
        private void UpgradeVersion(MyDbContext context, int newVersion, Action<int> upgradeAction) {
            //  If newVersion > currentVersion, call upgradeAction(newVersion) and set currentVersion to newVersion
            //  Else, return directly and do nothing.
            
        }
         
