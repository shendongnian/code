    public class Point {}
    public class RightTriangle:Point {
    	public double sideA {get; set;}
    	public double sideB {get; set;}
    }
    public class Circle:Point {
    	public double radius {get; set;}
    }
    public class Cone:Circle {
    	public double height {get; set;}
    }
