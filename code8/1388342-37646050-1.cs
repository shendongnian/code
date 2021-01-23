    public enum MyEnum
    {
        Val1,
        Val2,
        Val3
    }
    private MyEnum m_ActiveButton = MyEnum.Val1;
    public MyEnum ActiveButton
    {
        get
        {
            return m_ActiveButton;
        }
        set
        {
            m_ActiveButton= value;
            btn1.Enabled = false;
            btn2.Enabled = false;
            btn3.Enabled = false;
            switch (value)
            {
                case MyEnum.Val1:
                {
                    btn1.Enabled = true;
                    break;
                }
                case MyEnum.Val2:
                {
                    btn2.Enabled = true;
                    break;
                }
                case MyEnum.Val3:
                {
                    btn3.Enabled = true;
                    break;
                }
            }
        }
    }
