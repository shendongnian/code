    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
      using System.Windows.Forms;
      namespace RedBlackTree
    {
    
    class RBTree
     {
        public class node {
   
       public  node right, left, next, back,last;//for traversing the   
          public int id;//for regular implementation
            int day, month, year;//for root @ weeks
            int hour, min;//for shipment times
            byte amPm = 0;//for shipment times
           public char color = 'r';//color of node
           public Object data;//needed data of node
        }
        Queue<node> q = new Queue<node>();
        node head, tail, isRoot;
        node weeks, soNum, custByName;//main roots when customized
       
        node root = null;//for regular insert
       static Boolean allIsoff = false; 
        //regular insert 
        public void printRoot() {
            MessageBox.Show(root.id.ToString());
        }
        public void insert(int key, Object info) {
            allIsoff = false;
            node child = new node();
            child.id = key;
            child.data = info;
           if(root == null){
               root = child;
               child.color = 'b';
               return;
           }//end root is null
          //setup parent and grandParent nodes
           node parent = null;
           node grandParent = null;
            node GGparent = null;
           addNode(child, root, parent, grandParent,GGparent);
        }//end insert
        
        //for regular insertion
        private void addNode(node child, node current, node parent, node grandParent,node greatGparent){
           Boolean isTrue = false;//for child and current
           Boolean theRest = false;//for current and parent
           if(current.id == child.id){
               current.data = child.data;
               return;
           }
           if(current.id > child.id ){//going left
               if (current.left == null)
               {
                   current.left = child;//add child to the left
                   isTrue = isRed(current,child);
               
               }
               else {//continue left 
                   addNode(child, current.left, current, parent,grandParent);
                    
               
               }
           
           }//end going left
           else if (current.id < child.id) {//going right 
               if (current.right == null)
               {
                   current.right = child;
                   isTrue = isRed(current, child);
               }
               else {//continue right 
                   addNode(child, current.right, current, parent,grandParent);
               }
           
           }//end going right
           if (isTrue == false && allIsoff == false)//then check current and parent
           {
               
               theRest = isRed(current, parent);
               System.Diagnostics.Debug.WriteLine(current.id+" "+parent.id);
           }//end isTrue
            
           if(isTrue || theRest){//if there is a red clash
          
                if (isTrue) {
                    if (checkUncle(current, parent))
                    {
                        repaint(parent);
                        isTrue = false;
                    }
                    else
                    {
                        //rotate
                        if (current.id > child.id)
                        {//left of parent
                            if (parent != null)
                            {
                                if (parent.left == current)//P is left of Grandparent
                                {
                                    System.Diagnostics.Debug.WriteLine("T1.A");
                                    current.color = 'b';
                                    parent.color = 'r';
                                    rotateRight(current, parent, grandParent);
                                    allIsoff = true;
                                    return;
                                }
                                else
                                {//P is Right of Grandparent
                                    System.Diagnostics.Debug.WriteLine("T1.B");
                                    child.color = 'b';
                                    parent.color = 'r';
                                    rotateRight(child,current,parent);
                                    rotateLeft(parent,child,grandParent);
                                    allIsoff = true;
                                    return;
                                }
                            }//endif P != null
                           
                        }//end if current > child
                        else {//child is right of current
                            if (parent.left == current)//parent is left of grandparent
                            {
                                System.Diagnostics.Debug.WriteLine("T1.C");
                                rotateLeft(current, child, parent);
                                child.color = 'b';
                                parent.color = 'r';
                                rotateRight(child, parent, grandParent);
                                allIsoff = true;
                                return;
                            }
                            else
                            { //parent is right of grandparent
                                System.Diagnostics.Debug.WriteLine("T1.D");
                                rotateLeft(parent, current, grandParent);
                                current.color = 'b';
                                parent.color = 'r';
                                allIsoff = true;
                                return;
                            }
                        
                        
                        
                        
                        }//end else
                    }//END ELSE
                }//end isTure
                else if (theRest) {
                    if (checkUncle(parent, grandParent))
                    {
                        repaint(grandParent);
                        theRest = false;
                    }
                    else
                    {
                        //rotate
                        if (parent.id > current.id)
                        { //left of parent
                            if (grandParent != null)
                            {
                                if (grandParent.left == parent)//P is left of Grandparent
                                {
                                    System.Diagnostics.Debug.WriteLine("T2.A");
                                    grandParent.color = 'r';
                                    parent.color = 'b';
                                    rotateRight(parent,grandParent,greatGparent);
                                    allIsoff = true;
                                    return;
                                }
                                else
                                {//P is Right of Grandparent
                                    System.Diagnostics.Debug.WriteLine("T2.B");
                                    rotateRight(current, parent, grandParent);
                                    grandParent.color = 'r';
                                    current.color = 'b';
                                    rotateLeft(grandParent, current, greatGparent);
                                    allIsoff = true;
                                    return;
                                }
                            }//what if grandParent is null????????
                            else {
                                if (parent.right.color == 'b')//code should never execute
                                {
                                    System.Diagnostics.Debug.WriteLine("T2.C"); 
                                    current.color = 'b';
                                    rotateRight(current,parent,null);
                                    allIsoff = true;
                                    return;
                                }
                            
                            
                            }//end else for root rotation
                        }
                        else {//right of parent 
                            if (grandParent != null)
                            {
                                if (grandParent.left == parent)//P is left of Grandparent
                                {
                                    System.Diagnostics.Debug.WriteLine("T2.D");
                                    rotateLeft(parent,current,greatGparent);
                                    current.color = 'b';
                                    grandParent.color = 'r';
                                    rotateRight(current,grandParent,greatGparent);
                                    allIsoff = true;
                                    return;
                                }
                                else
                                {//P is Right of Grandparent
                                    System.Diagnostics.Debug.WriteLine("T2.E");
                                    rotateLeft(grandParent,parent,greatGparent);
                                    grandParent.color = 'r';
                                    parent.color = 'b';
                                    allIsoff = true;
                                    return;
                                }
                            }//what if grandParent is null????????
                            else
                            {
                                if (parent.left.color == 'b')//CODE SHOULD NEVER EXECUTE
                                {
                                    System.Diagnostics.Debug.WriteLine("T2.F");
                                    current.color = 'b';
                                    rotateLeft(parent,current,null);
                                    allIsoff = true;
                                    return;
                                }
                            }//end else for root rotation
                        
                        
                        }
                     
                    }//END ELSE
                
                }
               
            }//end red clash check
            
            
        }//end addNode
        public void repaint(node grandparent) {
            grandparent.right.color = 'b';
            grandparent.left.color = 'b';
            grandparent.color = 'r';
            if (grandparent == root) {
                grandparent.color = 'b';
            
            }
        }
        public Boolean checkUncle(node parent, node grandparent) {
            if (parent != null) {
                if (grandparent != null) {
                    if (grandparent.left == parent)
                    {
                        if (grandparent.right != null)
                        {
                            if (grandparent.right.color.Equals('r'))
                            {
                                return true;
                            }
                        }
                    }
                    else {
                        if (grandparent.left != null)
                        {
                            if (grandparent.left.color.Equals('r'))
                            {
                                return true;
                            }
                        }
                     
                    }
                
                
                }
            
            }
            return false;
        }//end check uncle
        public Boolean isRed(node a, node b) {
            if (a != null)
            {
                if (a.color.Equals('r'))
                {
                    if (b != null)
                    {
                        if (b.color.Equals('r'))
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        
        }
        //inorder traversal for testing
        String inorder = "";
        public void doTraversal() {
            inorderT(root);
        }
        public void inorderT(node current) {
            if (current != null)
            {
                inorder += current.id.ToString() + "(" + current.color.ToString() + "),";
                inorderT(current.left);
                inorderT(current.right);
            }
           
         
        }//end inorderT
        public String getInorder() {
            return inorder;
        }
        public void resetInorder() {
            inorder = "";
        }
        public void clearTree() {
            root = null;
        }
        //end methods for inorder traversal for testing
        public void breadthFirst() {
           
        
        
        }
        public void rotateLeft(node p, node q, node grand) {
            if (grand != null)
            {
                System.Diagnostics.Debug.WriteLine("hereRotateLeft !null");
                p.right = q.left;
                q.left = p;
                if (grand.right == p)
                {
                    grand.right = q;
                }
                else { grand.left = q; }
            }
            else {
                System.Diagnostics.Debug.WriteLine("hereRotateLeft else");
             
                p.right = q.left;
             
                q.left = p;
                root = q;
            
            }
        
        
        }//end left rotation
        public void rotateRight(node p, node q, node grand)
        {
            if (grand != null)
            {
                System.Diagnostics.Debug.WriteLine("hereRotateRight not null");
               
                q.left = p.right;
                p.right = q;
                if (grand.right == q)
                {
                    grand.right = p;
                }
                else { grand.left = p; }
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("hereRotateRight else");
                q.left = p.right;
              
                p.right = q;
                root = p;
            }
        }//end left rotation
    
        public void addLotForward() {
            for (int l = 0; l < 12; l++ )
            {
                insert(l, "");
            }
        }
      // Queue<node> q = new Queue<node>();
        //following code is for testing, breadth first search
        int[] arr = new int[]{1,2,4,8,16,32,64,128,256,512,1024,2048,4096,8192,16384};
        int i =0;
        int b = 0;
        int w = 0;
        int keeper = 0;
        public void BFS()
        {
            
       
            q.Enqueue(root);
            while (q.Count > 0)
            {
               
                node n = q.Dequeue();
                
                if (i == arr[b])
                {
                  
                    System.Diagnostics.Debug.Write("\r\n"+"("+n.id+""+n.color+")"); 
                    b++;
                    i =0 ;
                }
                else {
                    System.Diagnostics.Debug.Write("(" + n.id + "" + n.color + ")"); 
                
                }
                i++;
                if (n.id != -1)
                {
                    w = 0;
                    if (n.left != null)
                    {
                        q.Enqueue(n.left);
                    }
                    else
                    {
                        node c = new node();
                        c.id = -1;
                        c.color = 'b';
                        q.Enqueue(c);
                    }
                    if (n.right != null)
                    {
                        q.Enqueue(n.right);
                    }
                    else
                    {
                        node c = new node();
                        c.id = -1;
                        c.color = 'b';
                        q.Enqueue(c);
                    }
                }
                else {
                    w++;
                    node c = new node();
                    c.id = -1;
                    c.color = 'b';
                    q.Enqueue(c);
                    if (w == arr[b])
                    {
                       
                        break;
                    }
                }
              
               
                
            }
            q.Clear();
            w = 0;
            i = 0;
            b = 0;
            System.Diagnostics.Debug.Write("\r\n");
            return;
        }
    }//end main class
}
