        public int Temp
    {
        get { return temp; }
        set
        {
            if (value == temp) return;
            else if (temp == key)
                onKeyReached(this, EventArgs.Empty);
           //else
                temp = value;
        }
    }
