    bool Watch { get; set; }
        // Parent is control center, calling one child after another
        void Parent()
        {
            ChildOne(1);
            if (Watch == false)
                return;
            ChildTwo(1,3);
            if (Watch == false)
                return;
        }
       /// signature type 1
        void ChildOne(int a)
        {
        }
        /// signature type 2
        void ChildTwo(int a, int b)
        {
            Watch = false;
        }
 
