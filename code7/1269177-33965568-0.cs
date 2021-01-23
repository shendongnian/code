    class PlayerSequence
    {
        //ATTRIBUTES
        private bool[] sequence;
        //CONSTRUCTORS
        public PlayerSequence()
        {
        }
        public PlayerSequence(string sequence_String)//Seems to work!!
        {
            char[] sequence_array = sequence_String.ToCharArray();
            int inputLength = sequence_array.Length;
            int sequence_length = 0;
            for (int i = 0; i < inputLength; i++)
            {
                if (sequence_array[i] == '1' || sequence_array[i] == '0')
                {
                    sequence_length++;
                }
            }
            sequence = new bool[sequence_length];///KEYItem
            int input_index_adjustment = 0;
            for (int i = 0; i < inputLength; i++)
            {
                int sVal;
                if (!Int32.TryParse(sequence_String[i].ToString(), out sVal))
                {
                    input_index_adjustment++;
                    continue;
                }
                if (sVal == (Int32)1)
                    sequence[i - input_index_adjustment] = true;
                if (sVal == (Int32)0)
                    sequence[i - input_index_adjustment] = false;
                if (sVal != 1 && sVal != 0)
                    input_index_adjustment++;
            }
        }
        public override string ToString()//Works
        {
            string retString;
            retString = "";
            for (int i = 0; i < sequence.Length; i++)
            {
                if (sequence[i] == true) retString = retString + "T ";
                else retString = retString + "H ";
            }
            return retString;
        }
        public ulong Expectation()
        {
            ulong espTA = 0;
            for (int kexp = 0; kexp < sequence.Length; kexp++)
            {
                if (SeqCheck(sequence, kexp + 1))
                    espTA = espTA + (ulong)Math.Pow(2, kexp + 1);
            }
            return espTA;
        }//end Expectation
        public bool SeqCheck(bool[] toCheck, int k)
        {
            //Test of required property for each power of 2 here k
            int a = toCheck.Length;
            bool seqgood = false;
            bool[] checkStart = new bool[k];
            bool[] checkEnd = new bool[k];
            for (int i = 0; i < k; i++)
            {//loop sets up subarrays to compare
                checkStart[i] = toCheck[i];
                checkEnd[i] = toCheck[a - k + i];
            }
            for (int i = 0; i < k; i++)
            {//loop does comparison
                if (checkStart[i] != checkEnd[i])
                {
                    seqgood = false;
                    break;
                }
                seqgood = true;
            }
            return seqgood;
        }//end SeqCheck   
    }
