       public void Retrieve()
        {
           try
                {
                    using (var con = new SqlConnection(conStr))
                    {
                        var q = con.Query<PersonViewModel>("select firstName,lastName from Person where id = @id", new {id = personId}).First();
                        // Copy database data into the local properties so they will update the view...
                        this.personId = q.personId;
                        this.firstName = q.firstName;
                        ...
                        MessageBox.Show("Succesfully retrieved " + q.firstName + " "  +  q.lastName);
                    }
                }
                catch (Exception x)
                {
                    Console.WriteLine("error retrieving due to {0}", x.Message);
                }
        }
