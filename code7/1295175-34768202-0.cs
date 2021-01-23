    public class MyTimer : MonoBehaviour
    {
    float myTime = 0.0f;
    void Update()
    {
    UpdateTime();
    }
    
    public void UpdateTime()
    {
    myTime += Time.deltaTime;
    }
    
    }
