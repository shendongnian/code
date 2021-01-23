    /// <summary>
    /// CLass to store properties related to database
    /// </summary>
    class ObjectoA
    {
       public string A{get; set;}
       public string B{get; set;}
       public string C{ get; set; }
    }
    /// <summary>
    /// class to call method to update.
    /// 
    /// </summary>
    class ObjectB
    {
        /// <summary>
        /// update method.
        /// I would go with this solution.
        /// optionlay you can call the method which receive parameter of object
        /// </summary>
        /// <param name="A"> Object with properties mapped to database</param>
        /// <param name="updatetwoproperties">Optional paramneter to decide which update to run.
        /// the default value should be for update  that run most. For your need if you want to create an update methods for other
        /// two sets of parameter a suggest you create an Enum and pass this enum as optional parameter instead of bool parameter or you
        /// can pass as string and map each string value to specific update inside. IF YOU NEED EXAMPLE
        /// REPLAY ON COMMENTS</param>
        /// <returns></returns>
        public bool update(ObjectoA A, bool updatetwoproperties=false)
        {
            //method implementation
            if (updatetwoproperties)
            {
                //implement a update to all field
            }
            else
            {
                //implement update just to two field
            }
            return true;
        }
        /// <summary>
        /// update method based on parameter to update
        /// </summary>
        /// <param name="a">this properties is mapped on database</param>
        /// <param name="b">this propertie is mapped on database</param>
        /// <returns></returns>
        public bool update(string a, string b)
        {
            //method implementation e validate the return value
            return true;
        }       
    }
    /// <summary>
    /// I don't suggest to use this solution because
    /// it will add a method on string type while this method isn't related to string
    /// I just added here as a workaround for you.
    /// </summary>
