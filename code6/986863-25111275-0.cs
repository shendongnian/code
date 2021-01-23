    using System;
    using System.Windows.Forms;
    
    public class MyForm : Form
    {
        public MyForm()
        {
            var menuBuilder = new MenuBuilder();
            
            menuBuilder.FileLoaded += (sender, args) => UpdateDataInControls();
    
            Controls.Add(menuBuilder.GenerateMenuForMyForm());
            //load other controls into the form to visualize/manipulate data
        }
    
        public void UpdateDataInControls()
        {
            //reloads info into controls based on data in serializable class.
        }
    }
    
    internal class FileLoadedEventArgs : EventArgs
    {
        // customize event arguments if need be
    
        // e.g. public string FileName {get;set;}
    }
    
    public class MenuBuilder
    {
        // declare event delegate 
        internal delegate void FileLoadedEvent(object sender, FileLoadedEventArgs e);
    
        // declare event for observers to subscribe 
        internal event  FileLoadedEvent FileLoaded;
    
        public MenuStrip GenerateMenuForMyForm()
        {
            MenuStrip menu = new MenuStrip();
    
            /*
    
            ToolStripMenuItem loadfile = new ToolStripMenuItem();
            loadfile.name = "loadfile";
            loadfile.text = "Load File";
            loadfile.Click += new EventHandler(loadfile_Click);
            file.DropDownItems.Add(loadfile);
    
            */
    
            return menu;
        }
    
        void loadfile_Click(object sender, EventArgs e)
        {   
            // fire the event
            FileLoaded(this, new FileLoadedEventArgs());
        }
    }
