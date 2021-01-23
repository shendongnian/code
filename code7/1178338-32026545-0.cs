    using System;
    using System.IO;
    using System.Collections.Generic;
     
    class Program //class with main method that triggers the program execution
    {
        public static void Main()
        {
            List<Square> listOfSquares = new List<Square>(); // creating a List variable that could hold 'Square' type objects
     
    		//adding 'Square' type objects into the List
    		listOfSquares.Add(new Square(12)); 
            listOfSquares.Add(new Square(6));
            listOfSquares.Add(new Square(12));
            listOfSquares.Add(new Square(5));
            listOfSquares.Add(new Square(4));
            listOfSquares.Add(new Square(10));
            listOfSquares.Add(new Square(2));
            listOfSquares.Add(new Square(4));
            listOfSquares.Add(new Square(1));
            listOfSquares.Add(new Square(4));
    		//invoking the static method 'OrganiseSquares()' from Square class in-order
    		//to sort a set of squares one next to the other in increasing size order along the X axis.
            Square.OrganiseSquares(ref listOfSquares); 
        }
    }
    internal class Square
    {
        private double m_S;
        private double m_PX = 0;
        private double m_PY = 0;
     
        public Square(double p_S) //constructor
        {
            m_S = p_S;
        }
     
        public void SetXPosition(double p_PX) // method to set the value of one of the data members m_PX
        {
            m_PX = p_PX;
        }
     
        public void SetYPosition(double p_PY) // method to set the value of one of the data members m_PY
        {
            m_PY = p_PY;
        }
     
    	public double GetSide() // method to retrieve the value of one of the data members m_S
        {
            return m_S;
        }
     
    	//Method Description:
    	//The method OrganiseSquares gets a list of squares and modifies each square position 
    	//so the Squares are placed one next to the other in increasing size order along the X axis.
     
    	//Parameter Description:
    	//pio_Squares - The list of Squares as input and output. For the output the Squares should be sorted from smaller to bigger and in the right position. All the squares are in position 0,0 initially.
    	//return: The return value will be void as the imputed Square objects will be modified to set their position according to the algorithm.
     
    	//There must not be any space between squares.
     
    	public static void OrganiseSquares(ref List<Square> pio_Squares)
        {
        	double nextXPosition = 0;
     
    		SortBySide(ref pio_Squares); // Sorts the List of objects in the increasing order based on the value stored by 'm_S' data member of each Square type object
     
            for (int iterator = 0; iterator < pio_Squares.Count; iterator++) // iterate through the sorted list of objects and set the values for m_PX and m_PY accordingly
            {
            	if(iterator==0)
            	{
            		pio_Squares[iterator].SetYPosition(pio_Squares[iterator].GetSide());
            		nextXPosition = pio_Squares[iterator].GetSide();
            	}
     
            	else
            	{
            		pio_Squares[iterator].SetXPosition(nextXPosition);
            		pio_Squares[iterator].SetYPosition(pio_Squares[iterator].GetSide());
            		nextXPosition += pio_Squares[iterator].GetSide();
            	}
            }
     
            foreach(Square square in pio_Squares) //iterates through the sorted list of objects to print the values stored in each data member of every object sequentially
            {
                Console.WriteLine("Side:{0} X:{1} Y:{2}",square.GetSide(),square.m_PX,square.m_PY);
            }
        }
     
       //Method Description:
       //Method that implements Bubble sorting algorithm to sort the List of objects in the increasing order 
       //based on the value stored by 'm_S' data member of each Square type object
     
       //Parameter Description:
       //pio_Squares - - The list of squares as input and output. For the output the squares should be sorted from smaller to bigger and in the right position.
     
       public static void SortBySide(ref List<Square> pio_Squares) 
       {
        for (int iterator = 0; iterator < pio_Squares.Count; iterator++)
        {
            for (int index = 0; index < pio_Squares.Count - 1; index++)
            {
                if (pio_Squares[index].GetSide() > pio_Squares[index + 1].GetSide())
                {
                    Swap(ref pio_Squares, index);
                }
            }
        }
       }
     
       //Method Description:
       //Method that swaps 2 Square type objects from the List that would be passed by reference
     
       //Parameter Description:
       //pio_Squares - - The list of squares as input and output. For the output the squares having index & index+1 needs to be swapped
     
       public static void Swap(ref List<Square> pio_Squares, int index)
       {
       	Square temp = pio_Squares[index];
        pio_Squares[index] = pio_Squares[index+1];
        pio_Squares[index+1] = temp;
       }
     
    }
