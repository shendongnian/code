    // .NET 4.x async-await
    using UnityEngine;
    using System.Threading.Tasks;
    public class AsyncAwaitExample : MonoBehaviour
    {
         private async void Start()
         {
            Debug.Log("Wait.");
            await WaitOneSecondAsync();
            DoMoreStuff(); // Will not execute until WaitOneSecond has completed
         }
        private async Task WaitOneSecondAsync()
        {
            await Task.Delay(TimeSpan.FromSeconds(1));
            Debug.Log("Finished waiting.");
        }
    }
