    public class SpecialEvents
    {
    //first custom event
    public EventArgs e = null;
    public event StartEventHandler StartedElementsIconsUpdatedEvent;
    public delegate void StartEventHandler(SpecialEvents se, EventArgs e);
    public void StartElementsIconsUpdate()
    {
        if (StartedElementsIconsUpdatedEvent != null)
        {
            StartedElementsIconsUpdatedEvent(this, e);
        }
    }
    //second custom event
    public event EndEventHandler EndedElementsIconsUpdatedEvent;
    public delegate void EndEventHandler(SpecialEvents se, EventArgs e);
    public void EndElementsIconsUpdate()
    {
        if (EndedElementsIconsUpdatedEvent != null)
        {
            EndedElementsIconsUpdatedEvent(this, e);
        }
    }
    }
