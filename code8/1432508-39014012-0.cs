    public class MyData
    {
        private Node[] nodes = null;
        [System.Xml.Serialization.XmlElement("Node")]
        public Node[] Nodes 
        {  
            get { 
                    if(nodes == null) 
                    {
                        nodes = new Node[];
                    }
                    return nodes;
                }
            set { nodes = value ; }
        } 
    }
