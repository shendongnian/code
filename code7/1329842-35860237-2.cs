        internal class Node
        {
          public Node(){
            Level = -1;
          }
          public Node Parent { get; set; }
          private Node m_child;
          public Node Child
          {
            get { return m_child; }
            set
            {
              m_child = value;
              value.Parent = this;
              //Calculate Children
              m_child.CalculateLevel();
            }
          }
          public int Id { get; set; }
          public string Title { get; set; }
          public int Level {get; private set;}
          public void CalculateLevel(){
            //If no parent, I'm root! so level is 0
            if(Parent == null){
               this.Level = 0;
               return;
            }
            
            //Calculate parents level
            Parent.CalculateLevel();
            //My level is parent's level + 1.
            this.Level = Parent.Level + 1;
          }
        }
