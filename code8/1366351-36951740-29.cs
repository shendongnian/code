    void DeleteLinesWW(RichTextBox rtb, int fromLine, int count)
    {
        int nll = 1;  // <<===  pick the length of your new line character(s)!!
        int pS = rtb.Lines.Take(fromLine).Select(x => x.Length + nll).Sum() - nll;
        int pL = rtb.Lines.Take(fromLine + count).Select(x => x.Length + nll).Sum() - nll;
        if (pS < 0) { pS = 0; pL++; }
        rtb.SelectionStart = pS;
        rtb.SelectionLength = pL - pS ;
        bool readOnly = rtb.ReadOnly;
        rtb.ReadOnly = false;   // allow change even when the RTB is readonly
        rtb.Cut();
        rtb.ReadOnly = readOnly;  
      }
