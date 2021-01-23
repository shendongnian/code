    // New method, not depending on a gridview. Testable.
    public float calcNP_pure(int[] colB)
    {
        float[] NP = new float[colB.Length];
        float avgNP = 0;
        float min = colB.Min();
        float max = colB.Max();
        float a = 1, b = 10;
        for (int i = 0; i < rowcount; i++)
        {
            NP[i] = (a + (colB[i] - min) * (b - a)) / (max - min);
            avgNP = NP[i] + avgNP;
        }
        avgNP = (avgNP / rowcount) * 100;
        return avgNP;
    }
    // Not testable
    public float calcNP()
    {
        int rowcount = dataGridView1.Rows.Count;
        int[] colB = new int[rowcount];
        for (int i = 0; i < rowcount; i++)
        {
            colB[i] = Convert.ToInt32(dataGridView1.Rows[i].Cells[5].Value);
        }
        return calcNP_pure(colB);
    }
