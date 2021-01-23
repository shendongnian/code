    public class BodyConstructor
    {
    	public interface IBody
    	{
    		int Age { get; set; }
    		string Species { get; set; }
    		BodyPartGroup Head { get; set; }
    		BodyPartGroup Thorax { get; set; }
    		BodyPartGroup Abdomen { get; set; }
    		BodyPartGroup Pelvis { get; set; }
    	}
    
    	public interface IBodyPartGroup
    	{
    		BodyPartGroupType Type { get; set; }
    		List<IBodyPart> BodyParts { get; set; }
    	}
    
    	public interface IBodyPart
    	{
    		LateralDirection LateralOrientation { get; set; }
    		string Name { get; set; }
    		List<IBodyPart> SubParts { get; set; }
    		void Move();
    	}
    
    	public enum BodyPartGroupType
    	{
    		Head = 1,
    		Thorax = 2,
    		Abdomen = 3,
    		Pelvis = 4,
    	}
    
    	public enum LateralDirection
    	{
    		Central = 0,
    		Right = 1,
    		Left = 2,
    	}
    
    
    
    	public class Body : IBody
    	{
    		public Body()
    		{
    			Head = new BodyPartGroup(BodyPartGroupType.Head);
    			Thorax = new BodyPartGroup(BodyPartGroupType.Thorax);
    			Abdomen = new BodyPartGroup(BodyPartGroupType.Abdomen);
    			Pelvis = new BodyPartGroup(BodyPartGroupType.Pelvis);
    		}
    		public Body(int age, string species)
    			: this()
    		{
    			Age = age;
    			Species = species;
    		}
    		public int Age { get; set; }
    		public string Species { get; set; }
    		public BodyPartGroup Head { get; set; }
    		public BodyPartGroup Thorax { get; set; }
    		public BodyPartGroup Abdomen { get; set; }
    		public BodyPartGroup Pelvis { get; set; }
    
    		public void AddLimbs()
    		{
    			AddArms();
    			AddLegs();
    		}
    
    		public void AddArms()
    		{
    			// Individual segments for the left arm
    			BodyPart leftShoulder = new BodyPart("Left Shoulder", LateralDirection.Left);
    			BodyPart leftArm = new BodyPart("Left Arm", LateralDirection.Left);
    			BodyPart leftHand = new BodyPart("Left Hand", LateralDirection.Left);
    			leftArm.SubParts.Add(leftHand);
    			leftShoulder.SubParts.Add(leftArm);
    			// Individual segments for the right arm
    			BodyPart rightShoulder = new BodyPart("Right Shoulder", LateralDirection.Right);
    			BodyPart rightArm = new BodyPart("Right Arm", LateralDirection.Right);
    			BodyPart rightHand = new BodyPart("Right Hand", LateralDirection.Right);
    			rightArm.SubParts.Add(rightHand);
    			rightShoulder.SubParts.Add(rightArm);
    
    			// Add arms to thorax
    			Thorax.BodyParts.Add(rightShoulder);
    			Thorax.BodyParts.Add(leftShoulder);
    
    		}
    
    		public void AddLegs()
    		{
    			// Individual segments for the left leg
    			BodyPart leftHip = new BodyPart("Left Hip", LateralDirection.Left);
    			LeftLeg leftLeg = new LeftLeg(); // Here we use the LeftLeg class instead, which inherits BodyPart
    			BodyPart leftFoot = new BodyPart("Left Foot", LateralDirection.Left);
    			leftLeg.SubParts.Add(leftFoot);
    			leftHip.SubParts.Add(leftLeg);
    
    			//Individual segments for the right leg
    			BodyPart rightHip = new BodyPart("Right Hip", LateralDirection.Right);
    			BodyPart rightLeg = new BodyPart("Right Leg", LateralDirection.Right);
    			BodyPart rightFoot = new BodyPart("Right Foot", LateralDirection.Right);
    			rightLeg.SubParts.Add(rightFoot);
    			rightHip.SubParts.Add(rightLeg);
    
    			// Add legs to pelvis
    			Pelvis.BodyParts.Add(leftHip);
    			Pelvis.BodyParts.Add(rightHip);
    		}
    	}
    
    	public class BodyPartGroup : IBodyPartGroup
    	{
    		public BodyPartGroup()
    		{
    			BodyParts = new List<IBodyPart>();
    		}
    		public BodyPartGroup(BodyPartGroupType type)
    			: this()
    		{
    			this.Type = type;
    		}
    		public BodyPartGroupType Type { get; set; }
    		public List<IBodyPart> BodyParts { get; set; }
    	}
    
    	public class BodyPart : IBodyPart
    	{
    		public BodyPart()
    		{
    			SubParts = new List<IBodyPart>();
    		}
    		public BodyPart(string name, LateralDirection orientation)
    			: this()
    		{
    			Name = name;
    			LateralOrientation = orientation;
    		}
    		// Location of body part: Left, Central, Right
    		public LateralDirection LateralOrientation { get; set; }
    		public string Name { get; set; }
    		public List<IBodyPart> SubParts { get; set; }
    		public virtual void Move()
    		{
    			// Common body part movement code.
    		}
    	}
    
    	public class LeftLeg : BodyPart
    	{
    		public LeftLeg()
    		{
    			Name = "Left Leg";
    			LateralOrientation = LateralDirection.Left;
    		}
    		public override void Move()
    		{
    			// Custom left leg move code
    
    			base.Move(); // Call base BodyPart.Move();
    		}
    	}
    }
