    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace WoodCutter {
        /// <summary>
        /// This class represents a continuous area of wood
        /// </summary>
        public class Freespace {
            private int x, y, height, width;
            /// <summary>
            /// Public constructor of the class
            /// </summary>
            /// <param name="x">Leftmost position of the area</param>
            /// <param name="y">Topmost position of the area</param>
            /// <param name="height">Vertical extent of the area</param>
            /// <param name="width">Horizontal extent of the area</param>
            public Freespace(int x, int y, int height, int width) {
                this.x = x;
                this.y = y;
                this.height = height;
                this.width = width;
            }
            /// <summary>
            /// Leftmost position of the area
            /// </summary>
            public int xLeft {
                get { return this.x; }
            }
            /// <summary>
            /// Topmost position of the area
            /// </summary>
            public int yUp {
                get { return this.y; }
            }
            /// <summary>
            /// Tests if this area can contain a cut of the given height and width
            /// </summary>
            /// <param name="height">Vertical extent of the needed cut</param>
            /// <param name="width">Horizontal extent of the needed cut</param>
            /// <returns>true if this Freespce can contain the needed cut else false</returns>
            public bool Contains(int height, int width) {
                if (this.width >= width && this.height >= height) {
                    return true;
                }
                return false;
            }
            /// <summary>
            /// Creates cuts from this Freespace
            /// If the proposed cut does not intersect with this Freespace, do nothing and return a List containing this.
            /// If the proposed cut completely contains this Freespace, return an empty List.
            /// When the cut intersects the Freespace, cut the Freespace with the semiplanes around the desired cut
            /// </summary>
            /// <param name="x">Leftmost position of the cut</param>
            /// <param name="y">Topmost position of the cut</param>
            /// <param name="height">Vertical extent of the cut</param>
            /// <param name="width">Horizontal extent of the cut</param>
            /// <returns>List of Freespaces created from the intersection of the Freespace and the cut</returns>
            public List<Freespace> Cut(int x, int y, int height, int width) {
                List<Freespace> res = new List<Freespace>();
                if ((x - this.x) >= this.width || 
                    (y - this.y) >= this.height || 
                    (x + width) < this.x || 
                    (y + height) < this.y) {
                    // no intersection, return myself
                    res.Add(this);
                    return res;
                }
                if (x <= this.x && 
                    y <= this.y && 
                    (x + width) >= (this.x + this.width) && 
                    (y + height) >= (this.y + this.height)) {
                    // the cut covers the whole freespce, return empty list
                    return res;
                }
                if (x > this.x) {
                    // cut this freespace with the semiplane of abscissas less than x
                    res.Add(new Freespace(this.x, this.y, this.height, x - this.x));
                }
                if (y > this.y) {
                    // cut this freespace with the semiplane of ordinates less than y
                    res.Add(new Freespace(this.x, this.y, y - this.y, this.width));
                }
                if ((x + width) < (this.x + this.width)) {
                    // cut this freespace with the semiplane of abscissas greater than x+width
                    res.Add(new Freespace(x + width, this.y, this.height, this.width - width));
                }
                if ((y + height) < (this.y + this.height)) {   
                    // cut this freespace with the semiplane of ordinates greater than y+height
                    res.Add(new Freespace(x, y + height, this.height - height, this.width));
                }
                return res;
            }
            public void Write2Console() {
                Console.WriteLine("Freespace at {0},{1} of dimensions {2},{3}", this.x, this.y, this.width, this.height);
            }
        }
        /// <summary>
        /// This class holds a List of Freespaces that can be cut
        /// At the beginning you have only one Freespace covering the whole plane, 
        /// adding cuts the List gets populated with all the residual areas.
        /// </summary>
        public class Wood {
            private List<Freespace> freeSpaces;
            /// <summary>
            /// Public constructor
            /// </summary>
            /// <param name="height">Vertical extent of the area</param>
            /// <param name="width">Horizontal extent of the area</param>
            public Wood(int height, int width) {
                this.freeSpaces = new List<Freespace>();
                this.freeSpaces.Add(new Freespace(0, 0, height, width));
            }
            /// <summary>
            /// Returns the first Freespace (or null) that can contain the whole cut
            /// </summary>
            /// <param name="height">Vertical extent of the cut</param>
            /// <param name="width">Horizontal extent of the cut</param>
            /// <returns>First Freespace completely containing the cut or null</returns>
            public Freespace canCut(int height, int width) {
                foreach (Freespace f in this.freeSpaces) {
                    if (f.Contains(height, width)) {
                        return f;
                    }
                }
                return null;
            }
            /// <summary>
            /// Makes the cut in the Wood.
            /// Intersects the desired cut with all the Freespaces in the List.
            /// WARNING. No check is made, at this point, if you can do the cut. 
            ///          You have to call the canCut function before using this method 
            ///          and take the adequate coordinates from the Freespace returned.
            /// </summary>
            /// <param name="x">Leftmost position of the cut</param>
            /// <param name="y">Topmost position of the cut</param>
            /// <param name="height">Vertical extent of the cut</param>
            /// <param name="width">Horizontal extent of the cut</param>
            public void Cut(int x, int y, int height, int width) {
                List<Freespace> freeSpaces = new List<Freespace>();
                foreach (Freespace f in this.freeSpaces) {
                    freeSpaces.AddRange(f.Cut(x, y, height, width));
                }
                this.freeSpaces = freeSpaces;
            }
            public void Write2Console() {
                foreach (Freespace f in this.freeSpaces) {
                    f.Write2Console();
                }
            }
        }
        class WoodCutter {
            /// <summary>
            /// Tests if a cut can be made in the wood and, if true
            /// cuts it at the upper leftmost coordinate of the first
            /// adequate Freespace found.
            /// </summary>
            /// <param name="wood">The wood to cut</param>
            /// <param name="width">The width of thr cut</param>
            /// <param name="heigth">The height of the cut</param>
            private static void testCut(Wood wood, int width, int heigth) {
                Freespace f;
                f = wood.canCut(heigth, width);
                if (f != null) {
                    Console.WriteLine("Can cut a {0} by {1} piece", width, heigth);
                    wood.Cut(f.xLeft, f.yUp, heigth, width);
                } else {
                    Console.WriteLine("Cannot fit a {0} by {1} piece", width, heigth);
                }
            }
            static void Main(string[] args) {
                // Let's start with a 200X200 wood
                Wood wood = new Wood(200, 200);
                wood.Write2Console();
                //Try and cut a 100X100 piece
                testCut(wood, 100, 100);
                wood.Write2Console();
                //Try and cut a 50X50 piece
                testCut(wood, 50, 50);
                wood.Write2Console();
                //Try to cut a 100X200 piece (this should fail)
                testCut(wood, 100, 200);
                wood.Write2Console();
                //Try and cut a 200X100 piece
                testCut(wood, 200, 100);
                wood.Write2Console();
                Console.WriteLine("Program end.");
            }
        }
    }
