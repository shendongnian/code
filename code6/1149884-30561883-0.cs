    using System.Drawing;
    using System.Windows.Forms;
    namespace jkHTMLBuilder
    {
        public class QuadCheckTreeNode : TreeNode
        {
            public enum CheckState : int { UnChecked, Checked, Chair, Rank }    // The four possible states
            private CheckState _cs = CheckState.UnChecked;                      // The node's current state
            public CheckState checkState
            {
                get
                {
                    return _cs;
                }
                set
                {
                    _cs = value;
                }
            }
            public QuadCheckTreeNode(string initString) : base()
            {
                this.Text = initString;
                this.checkState = CheckState.UnChecked;
                this.Checked = false;
                this.StateImageIndex = 0;
            }
            public void checkAdvance()                                          // This is called from onAfterCheck to set the next consecutive state
            {
                switch (checkState)
                {
                    case CheckState.UnChecked:
                        checkState = CheckState.Checked;
                        break;
                    case CheckState.Checked:
                        checkState = CheckState.Chair;
                        break;
                    case CheckState.Chair:
                        checkState = CheckState.Rank;
                        break;
                    case CheckState.Rank:
                        checkState = CheckState.UnChecked;
                        break;
                }
                this.Checked = (this.checkState == CheckState.UnChecked ? false : true);
            }
        }
        class QuadCheckTreeView : TreeView
        {
            private bool clickStop = false;
            private bool shouldAdvance = false;
            public QuadCheckTreeView() : base()
            {
                StateImageList = new ImageList();
            }
            public void populateStateImageList()                                // I made this a separate method and call it from my Load_Senators method so the images are
            {                                                                   // set up when the XML file is loaded.  Apparently, loading the files ( Check*.bmmp )
                for (int i = 0; i < 2; i++)                                     // from the ctor causes problems...?  Whatever.  This works.
                {
                    Bitmap bmp = new Bitmap(16, 16);
                    Graphics chkGraphics = Graphics.FromImage(bmp);
                    switch (i)
                    {
                        case 0:
                            CheckBoxRenderer.DrawCheckBox(chkGraphics, new Point(0, 1), System.Windows.Forms.VisualStyles.CheckBoxState.UncheckedNormal);
                            break;
                        case 1:
                            CheckBoxRenderer.DrawCheckBox(chkGraphics, new Point(0, 1), System.Windows.Forms.VisualStyles.CheckBoxState.CheckedNormal);
                            break;
                    }
                    StateImageList.Images.Add(bmp);
                }
                Bitmap myBitmap = new Bitmap("..\\..\\CheckBlue.bmp");
                StateImageList.Images.Add(myBitmap);
                myBitmap = new Bitmap("..\\..\\CheckRed.bmp");
                StateImageList.Images.Add(myBitmap);
            }                               
            public void ClearNodes(TreeNodeCollection nodes)                    // This is for when I move on to the next record.  Unchecks everything.
            {
                clickStop = true;
                foreach (QuadCheckTreeNode qctn in nodes)
                {
                    qctn.Checked = false;
                    qctn.checkState = QuadCheckTreeNode.CheckState.UnChecked;
                    if (qctn.Nodes.Count > 0)
                    {
                        foreach (QuadCheckTreeNode cqctn in qctn.Nodes)
                        {
                            cqctn.Checked = false;
                            cqctn.checkState = QuadCheckTreeNode.CheckState.UnChecked;
                        }
                    }
                }
                clickStop = false;
            }
            protected override void OnCreateControl()
            {
                base.OnCreateControl();
                CheckBoxes = false;                                             // Checkboxes off to use my images
                ClearNodes(this.Nodes);                                         // Probably not needed.
            }
            protected override void OnNodeMouseClick(TreeNodeMouseClickEventArgs e)
            {
                base.OnNodeMouseClick(e);
                TreeViewHitTestInfo tvhtInfo = HitTest(e.X, e.Y);               // If you didn't click on it, ignore.
                if (tvhtInfo == null || tvhtInfo.Location !=
                TreeViewHitTestLocations.StateImage)
                {
                    return;
                }
                QuadCheckTreeNode qctn = (QuadCheckTreeNode)e.Node;             // If you right-clicked, set to UnChecked
                if (e.Button == MouseButtons.Right)
                {
                    if (qctn.checkState != QuadCheckTreeNode.CheckState.UnChecked)
                    {
                        qctn.checkState = QuadCheckTreeNode.CheckState.UnChecked;
                        qctn.Checked = false;
                        shouldAdvance = false;
                    }
                }
                else
                    shouldAdvance = true;                                       // Left click sets this var==true so the node's Advance() method is called
                qctn.Checked = qctn.Checked;                                    // This fires the onAfterCheck event
            }
            protected override void OnAfterCheck(TreeViewEventArgs e)
            {
                base.OnAfterCheck(e);
                if (clickStop)                                                  // This keeps the event from running if it's called inappropriately
                {
                    return;
                }
                clickStop = true;
                QuadCheckTreeNode qctn = (QuadCheckTreeNode)e.Node;
                if (shouldAdvance)
                {
                    qctn.checkAdvance();
                    shouldAdvance = false;
                    qctn.StateImageIndex = (int)qctn.checkState;
                }
                checkParent(qctn);                                              // Calling this method, if it actually checks a parent node, won't call onAfterCheck because of clickStop
                clickStop = false;
            }
            protected void checkParent(QuadCheckTreeNode qctn)
            {
                QuadCheckTreeNode pqctn = (QuadCheckTreeNode)qctn.Parent;
                if (pqctn == null)
                    return;
                if (pqctn.checkState == QuadCheckTreeNode.CheckState.UnChecked) // This checks a parent if it has a checked child
                {
                    bool chkParent = false;
                    foreach (QuadCheckTreeNode n in pqctn.Nodes)
                    {
                        if (n.checkState != QuadCheckTreeNode.CheckState.UnChecked)     // Checks all the children.  If even one is checked, the parent gets checked
                            chkParent = true;
                    }
                    if (chkParent)
                    {
                        pqctn.Checked = true;
                        pqctn.checkState = QuadCheckTreeNode.CheckState.Checked;
                    }
                }
            }
        }
    }
