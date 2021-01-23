    [DllImport("ColorRamps.dll")]
    static extern void ColorRamps_getColorRampTable(int n, int* table);
    
    public unsafe static void getColorRampTable(int[] table)
    {
        int n = table.Length;
        fixed (int* pTable = &table[0])
        {
          ColorRamps_getColorRampTable(n, pTable);
        }
    }
