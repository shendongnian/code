    public virtual Buttons Execute(){
        this.holder.SetActive(true); // Set the window active
        clicked = null; // Set the state as undetermined
        while (clicked == null) { // Wait until it is set
          Application.DoEvents(); // Process messages
          Thread.Sleep(10); // Wait for a while
        }
        return clicked; // Returns the button clicked.
    }
