    List<Person> ppl = people.Where(x => x.dob.Month == DateTime.Today.Month && 
                                    x.dob.Day == DateTime.Today.Day).ToList();
    MessageBox.Show(string.Format("There are {0} people with this dob", ppl.Count));
    foreach(Person p in ppl)
        MessageBox.Show(string.Format("Hello, today is {0}. Birthday of person {1}", DateTime.Today, p.Name), "Hello", MessageBoxButtons.OK); 
