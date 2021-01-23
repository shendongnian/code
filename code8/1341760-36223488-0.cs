            // Execute the insert operation.
            table.Execute(insertOperation);//Wrap this in its own try/catch block and catch and handle StorageException type Exception.
            //This piece of code is not really needed.
            /*
            if (table.Execute(insertOperation).HttpStatusCode == 403 ||
                table.Execute(insertOperation).HttpStatusCode == 409)
            {
                Debug.WriteLine("Account already registered with that Email Address");
            }
            else if (table.Execute(insertOperation) != null &&
                table.Execute(insertOperation).HttpStatusCode == 200)
            {
                Debug.WriteLine("Account successfully registered");
            }
            */
