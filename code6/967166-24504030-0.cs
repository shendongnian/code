    List<SelectList> filedNullOrEmpty = list.Where(item => item.Text == null ||     item.Text.Equals(string.Empty)).ToList();
      foreach (Select selobj in filedNullOrEmpty)
      {
       list.Remove(selobj);
      }       
  
