    namespace DoubleClick
    {
        public static class MonoBehaviourExtension
        {
            public static void StartCoroutine(this MonoBehaviour mb, params Action[] funcs)
            { 
                mb.StartCoroutine(CoroutineRunnerSimple(funcs));
            }
            private static System.Collections.IEnumerator CoroutineRunnerSimple(Action[] funcs)
            {
                foreach (var func in funcs)
                {
                    if (func != null)
                        func();
                    yield return new WaitForSeconds(.01f);
                }
            }
        }
        abstract public class DoubleClickBehaviorBase : MonoBehaviour
        {
            float _DoubleClickTimer = 0.0f;
            float _DoubleClickDelay = 0.5f;
            bool _WasClicked = false;
            // Update is called once per frame
            protected virtual void Update()
            {
                // this starts timing when a click occurs 
                //
                if (this._WasClicked == true)
                {
                    this._DoubleClickTimer += Time.deltaTime;
                }
                // this must be in update because it expires based on time and not clicks
                //
                if (this._DoubleClickTimer > this._DoubleClickDelay)
                {
                    this._WasClicked = false;
                    this._DoubleClickTimer = 0.0f;
                    
                }
            }
            protected virtual void OnMouseDoubleClick()
            {
            }
            protected virtual void OnMouseDown()
            {
                if (this._WasClicked == false && this._DoubleClickTimer < _DoubleClickDelay)
                {
                    this._WasClicked = true;
                }
                else if (this._WasClicked == true && 
                         this._DoubleClickTimer < this._DoubleClickDelay)
                {
                    this.StartCoroutine(() => this.OnMouseDoubleClick());
                }
            }
        }
    }
