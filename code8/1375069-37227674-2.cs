    // the arm class encapsulates the parts of the arm (the data), and the behavior of the arm (the methods).
    class Arm
    {    
        Shoulder shoulder = new Shoulder();
        Hand hand = new Hand();
        UpperArm upperArm = new UpperArm();
        Elbow elbow = new Elbow();
        LowerArm lowerArm = new LowerArm();
        void poke()
        {         
            flinch();
        }
        void flinch()
        {
            // write some code that flinches the arm
        }
        void move()
        {
             // move the arm all over the place 
             shoulder.move();
             hand.wave(); 
             doHighFive();
             //...  
        }
        void doHighFive()
        {
             // move all the arm parts in a high-five motion
        }
    }
    // the Body class encapsulates the parts of the body (the data), and the behavior of the body (the methods).
    class Body
    {    
        Head head = new Head();
        Torso torso = new Torso();
        Arm leftArm = new Arm();
        Arm rightArm = new Arm();
        Leg leftLeg = new Leg();
        Leg rightLeg = new Leg();
        void poke()
        {         
            flinch(); 
            dance();
            System.out.println("I didn't flinch, I was just dancing! Now I'm tired, though."); 
            goToBed();
        }
        void flinch()
        {
            // write some code that makes the body flinch
        }
        void dance()
        {
             // write code to make the body dance
        }
        void goToBed()
        {
             // write code to make the body go to bed
        }
    }
