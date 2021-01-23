        [XmlRoot("ignoredPaths")]
        public class IgnoredPaths
        {
            PathElementCollection paths {get;set;}
        }
        [XmlInclude(typeof(Remove))]
        [XmlInclude(typeof(Add))]
        public class PathElementCollection
        {
            [XmlAttribute("path")]
            public string path {get;set;}
        }
        [XmlRoot("remove")]
        public class Remove : PathElementCollection
        {
        }
        [XmlRoot("add")]
        public class Add : PathElementCollection
        {
        }​
