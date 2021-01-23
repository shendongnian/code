       internal class Node
        {
          public Node(){
            Level = -1;
            Parents = new List<Node>();
          }
          public List<Node> Parents { get; set; }
          private Node m_child;
          public Node Child
          {
            get { return m_child; }
            set
            {
              m_child = value;
              value.Parents.Add(this);
              m_child.CalculateLevel();
            }
          }
          public int Id { get; set; }
          public string Title { get; set; }
          public int Level {get; private set;}
          public void CalculateLevel(){
            if(Parents.Count() == 0){
              this.Level = 0;
              return;
            }
            foreach (var parent in this.Parents)
            {
               parent.CalculateLevel();
            }
            
            this.Level = Parents.Select(p => p.Level).Max() + 1;
          }
        }
