    class Columns : MSColumnClass
    {
        String        Name;   // name of db column
        CCData        value;  // CCData contains int / long / String / Date
    }
    class row_data
    {
        std::list<Columns>      *m_colum
        long                    row;
        long                    my_key;
    }
