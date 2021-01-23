    List<Osoba> newList = new List<Osoba>();
    string search = textBox1.Text;
    
    foreach (Osoba item in listOsob)
    {
       var props = item.GetType().GetProperties();
       foreach (var prop in props)
       {
          if (Convert.ToString(prop.GetValue(item, null)).Contains(search))
          {
              newList.Add(item);
              break;
          }
       }
    }
    dataGridView1.DataSource = search == "" ? listOsob : newList;
