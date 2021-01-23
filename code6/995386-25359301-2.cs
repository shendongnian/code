        //using System.Threading.Tasks;
        DbInfoPackage migratedData = null;
        DbInfoPackage nonMigratedData = null;
        Task firstTask = Task.Run(() => { migratedData = …; });
        Task secondTask = Task.Run(() => { nonMigratedData = …; });
        …
        Task.WaitAll(firstTask, secondTask);
