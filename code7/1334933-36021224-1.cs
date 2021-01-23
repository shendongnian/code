     class Word {
                public string Word { get; set; }
                public string Color { get; set; }
        }
    
        class array
        {
            public Word[] array1 { get; set; }
            public Word[] array2 { get; set; }
        }
    
        array[] array = new array[1];
        array[0] = new array()
        {
            array1 = new Word[]
            {
                new Word()
                {
                    Word = "Word1",
                    Color = "Blue"
                },
                new Word()
                {
                    Word = "Word2",
                    Color = "Green"
                },
                new Word()
                {
                    Word = "Word3",
                    Color = "Yellow"
                }
            },
            array2 = new Word[]
            {
                new Word()
                {
                    Word = "Word4",
                    Color = "Black"
                }
            }
        };
