            public static class foo
        {
            public static int lineno;
        }
            private void LineEvent(object sender, EventArgs eArgs)
        {
            int IndexCoun = rtb1.SelectionStart;//Index count where actually the mouse is clicked in the richtextbox
            foo.lineno = rtb1.GetLineFromCharIndex(IndexCoun);//Get the line no
        }
