        public static List<T> GetAllControlsInside<T>(Control control)
        {
            List<Control> result = new List<Control>();
            GetAllControlsInside<T>(control, result);
            return result.OfType<T>().ToList();
        }
        private static void GetAllControlsInside<T>(Control control, List<Control> result)
        {
            foreach (Control ctrl in control.Controls)
            {
                result.Add(ctrl);
                if (ctrl.HasChildren && !(ctrl is T))
                {
                    GetAllControlsInside<T>(ctrl, result);
                }
            }
        }
    private bool checkSolved()
    {
        bool isSolved = true; //Solve Variable
        foreach (TextBox tb in GetAllControlsInside<TextBox>(this)) //Iterates through all textboxes
        {
           if (String.IsNullOrEmpty(tb.Text)) //Checks to see if one of them is null
           {
              isSolved = false; //Sets bool to false
           }
        }
        return isSolved; //Returns bool
    }
