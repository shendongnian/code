        public partial class Form1 : Form
        {
            int randCode;
            int[] codes = { 39835, 72835, 49162, 29585, 12653, 87350, 74783};
        ....
        randcode = mRandom.Next(0, codes.Length);
