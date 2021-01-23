    class C
    {
        private Member mem;
        private Robot bot;
        private class Robot
        {
            C owner;
            public Robot(C c) {owner = c;}
            public void function()
            { 
               // Robot can use owner.mem here
            }
        };
    }
