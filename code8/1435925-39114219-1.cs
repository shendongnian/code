    public bool ConvertToBool(string op, bool a, bool b)
    {
        var st = new Stack<bool>();
        var opArray = op.ToCharArray();
        var orFlag = false;
        var andFlag = false;
        for (var i = 0; i < opArray.Length; i++)
        {
            bool top;
            switch (opArray[i])
            {
                case '|':
                    i++;
                    orFlag = true;
                    break;
                case '&':
                    i++;
                    andFlag = true;
                    break;
                case 'a':
                    if (orFlag)
                    {
                        top = st.Pop();
                        st.Push(top || a);
                        orFlag = false;
                    }
                    else if (andFlag)
                    {
                        top = st.Pop();
                        st.Push(top && a);
                        andFlag = false;
                        continue;
                    }
                    st.Push(a);
                    break;
                case 'b':
                    if (orFlag)
                    {
                        top = st.Pop();
                        st.Push(top && b);
                        orFlag = false;
                    }
                    else if (andFlag)
                    {
                        top = st.Pop();
                        st.Push(top && b);
                        andFlag = false;
                        continue;
                    }
                    st.Push(b);
                    break;
            }
        }
        return st.Pop();
    }
