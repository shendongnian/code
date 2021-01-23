    dynamic jsonData = new System.Dynamic.ExpandoObject();
    jsonData.age = kid.age;
    jsonData.name = kid.name;
    for (int i = 0; i < kid.toys.Count; i++)
            {
                ((IDictionary<String, Object>)jsonData).Add(string.Format("toy_{0}", i), kid.toys[i]);
            }
