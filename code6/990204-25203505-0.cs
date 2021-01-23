    void Timer2_Click(object sender, EventArgs e)
    {
        #region ListBox Remove And Effect / in Process
        if (works.Count > 1)
        {
            //Work workTemp = works[0];  //Don't know if really needed
              var fade = new DoubleAnimation()
              {
                 From = 1,
                 To = 0,
                 Duration = TimeSpan.FromSeconds(5),
              };
           var item = //TheListBox.Items[];
           Storyboard.SetTarget(fade, item);
           Storyboard.SetTargetProperty(fade,
                                        new PropertyPath(ListBoxItem.OpacityProperty));
           var sb = new Storyboard();
           sb.Children.Add(fade);
           sb.Completed += sb_Completed;
           sb.Begin(); 
           
        }
    }
        void sb_Completed(object sender, EventArgs e)
        {
             works.RemoveAt(0); 
             //works.Add(workTemp);  //Don't know if really needed
             DataContext = this; // BindGrid --Is that correct to define the context each time you click ? :(
        }
