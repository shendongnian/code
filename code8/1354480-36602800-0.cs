    private int speed { get; set; }
    private int gear { get; set; }
    private bool reduceSpeed { get; set; }
    public Car(int speedCurrent, int gearCurrent) {
        speed = speedCurrent;
        gear= startGear;
        if (speed > 30)
            reduceSpeed = true; // do further processing with this.
        ...
    }
