            public void Move(char[] input, int position, int offset, int direction) {
            int newPosition;
            if (direction == 0) {
                //Move Left
                newPosition = position - offset;
            }
            else {
                //Move Right
                newPosition = position + offset;
            }
            if (newPosition < 0 || newPosition > input.Length-1) {
                throw new ArgumentException("Offset is invalid", "offset");
            }
            input[newPosition] = input[position];
            input[position] = ' ';
        }
