    class Node {
       public string Name;
       public IEnumerbale<Node> Children;
    }
    void Main(){
       var tree = new List<Node>();//fill it somehow
       foreach(var node in tree){
          DFS(node);
       }
    }
    void DFS(Node root){
       foreach(var node in root.Children){
          node.Name = root.Name + '/' + node.Name;
          DFS(node);
       }  
    }
