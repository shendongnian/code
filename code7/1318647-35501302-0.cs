     public string Name
            {
                get { return m_Name; }
                set
                {
                    if (m_Name != value)
                    {
                        m_Name = value;
                        OnChange("Name");
                    }
                }
            }
