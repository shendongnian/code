			string test = ""; ;
            con.Open();
            SqlCommand get = new SqlCommand("select * from Color_Subjects", con);
            SqlDataReader read = get.ExecuteReader();
            List<Subject> subjects = new List<Subject>(); // Declare a list of subjects
            while (read.Read())
            {
                subjects.Add(new Subject()
                {
                    SubjectName = read.GetString(0),
                    Color = ((int)read.GetValue(1))
                });
			}
                //Get All Unique Colors
			List<int> allColors = subjects.Select(x => x.Color).Distinct().ToList();
			//Iterate through each color and get subjects associated with that color
			foreach (int thisColor in allColors)
			{
				List<Subject> subjectsForThisColor = subjects.Where(x => x.Color == thisColor).ToList();
				// Output to console -- 
				foreach (Subject s in subjectsForThisColor)
				{
					//Console.WriteLine(s.SubjectName + " - " + s.Color);
					test += s.SubjectName + " -" + s.Color + "\n";
				}
			}
            TextBox7.Text = test;
