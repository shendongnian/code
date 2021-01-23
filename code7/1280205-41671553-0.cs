            public interface ICellT9
            {
                void Add(string a_name);
                List<string> GetNames(string a_number);
            }
            public class Cell : ICellT9
            {
                private Dictionary<int, Cell> m_nodeHolder;
                private List<string> m_nameList;
                public Cell()
                {
                    m_nodeHolder = new Dictionary<int, Cell>();
                    for (int i = 2; i < 10; i++)
                    {
                        m_nodeHolder.Add(i, null);
                    }
                }
                public void Add(string a_name)
                {
                    Add(a_name, a_name);
                }
                private void Add(string a_name, string a_originalName)
                {
                    if ((string.IsNullOrEmpty(a_name) == true) && (string.IsNullOrEmpty(a_originalName) == false))
                    {
                        if (m_nameList == null)
                        {
                            m_nameList = new List<string>();
                        }
                        m_nameList.Add(a_originalName);
                    }
                    else
                    {
                        int l_firstNumber = CharToNumber(a_name[0].ToString());
                        if (m_nodeHolder[l_firstNumber] == null)
                        {
                            m_nodeHolder[l_firstNumber] = new Cell();
                        }
                        m_nodeHolder[l_firstNumber].Add(a_name.Remove(0, 1), a_originalName);
                    }
                }
                public List<string> GetNames(string a_number)
                {
                    List<string> l_result = null;
                    if (string.IsNullOrEmpty(a_number))
                    {
                        return l_result;
                    }
                    int l_firstNumber = a_number[0] - '0';
                    if (a_number.Length == 1)
                    {
                        l_result = m_nodeHolder[l_firstNumber].m_nameList;
                    }
                    else if(m_nodeHolder[l_firstNumber] != null)
                    {
                        l_result = m_nodeHolder[l_firstNumber].GetNames(a_number.Remove(0, 1));
                    }
                    return l_result;
                }
        
                private int CharToNumber(string c)
                {
                    int l_result = 0;
                    if (c == "a" || c == "b" || c == "c")
                    {
                        l_result = 2;
                    }
                    else if (c == "d" || c == "e" || c == "f")
                    {
                        l_result = 3;
                    }
                    else if (c == "g" || c == "h" || c == "i")
                    {
                        l_result = 4;
                    }
                    else if (c == "j" || c == "k" || c == "l")
                    {
                        l_result = 5;
                    }
                    else if (c == "m" || c == "n" || c == "o")
                    {
                        l_result = 6;
                    }
                    else if (c == "p" || c == "q" || c == "r" || c == "s")
                    {
                        l_result = 7;
                    }
                    else if (c == "t" || c == "u" || c == "v")
                    {
                        l_result = 8;
                    }
                    else if (c == "w" || c == "x" || c == "y" || c == "z")
                    {
                        l_result = 9;
                    }
                    return l_result;
                }
            }
