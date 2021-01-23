    class ProjectsCollectionImpl : ProjectsCollection {
        public Project Open(string path) {
            return ...
        }
    }
    Engineering eng = new Engineering(new ProjectsCollectionImpl());
    MethodInfo info = type.GetMethod("Open");
    var proj = info.Invoke(eng.project, new object[] {path});
