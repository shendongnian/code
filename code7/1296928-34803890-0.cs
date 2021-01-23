    class C
    {
        private Member mem;
        private Robot bot;
        private class Robot
        {
            C owner;
            public Robot(C c) {owner = c;}
            public void function() { //Robot needs to use owner.mem here, 
                                 //but can't because it's private}
        };
    }
