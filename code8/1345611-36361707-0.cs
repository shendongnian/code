        void newFrameHandler(Frame frame)
        {
            foreach(Finger in frame.Fingers){
                Vector fingerPosition = finger.TipPosition;
                //Do something with this information...
            }
        }
