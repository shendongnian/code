    using UnityEngine;
    using UnityEngine.UI;
    using System.Collections;
    public class Display : MonoBehaviour
    {
        public GameObject bubble1;
        public GameObject bubble2;
        public GameObject bubble3;
        public GameObject bubble4;
        public GameObject bubble5;
        public GameObject bubble6;
        private int c = 0;
        private int z = 0;
        private int[] a = new int[6];
        private GameObject[] enlarge = new GameObject[6];
        void Start()
        {
            int ch, t, k = 0;
            string str = "";
            float tim;
            GameObject[] bubble = {bubble1, bubble2, bubble3, bubble4, bubble5, bubble6};
            for (int i = 1; i < 6; i++)
            {
                str = "0";
                if (c == 0)
                {
                    foreach (GameObject b in bubble)
                    {
                        b.transform.localScale = new Vector3(1F, 1F, 0F);
                        str += b.transform.tag;
                    }
                    c++;
                    for (int j = 0; j < 6; j++)
                    {
                        ch = 0;
                        while (true)
                        {
                            ch = Random.Range(0, 6);
                            if (a[ch] == 0)
                            {
                                a[ch] = 1;
                                str += "2";
                                break;
                            }
                        }
                        str += "3";
                        t = -1;
                        foreach (GameObject b in bubble)
                        {
                            t++;
                            if (t == ch)
                            {
                                b.transform.localScale = new Vector3(1F, 1F, 0F);
                                enlarge[k++] = b;
                                transform.localScale = new Vector3(1F, 1F, 0F);
                                StartCoroutine("waitthreesec");
                            }
                            str += "4";
                        }
                    }
                }
            }
        }
        IEnumerator waitthreesec()
        {
            //print ("Thread");
            Debug.Log("Coroutine hit");
            yield return new WaitForSeconds(2);
            Debug.Log("Just waited 2 seconds");
        }
        // Update is called once per frame
        void Update()
        {
            float tim;
            string str = "";
            Time.timeScale = 0.5F;
            print(Time.fixedTime + "");
            if (a[0] == 1)
            {
                bubble1.transform.localScale = new Vector3(1F, 1F, 0F)*Time.time;
            }
            if (a[1] == 1)
            {
                bubble2.transform.localScale = new Vector3(1F, 1F, 0F)*Time.time;
            }
            if (a[2] == 1)
            {
                //Time.timeScale = 0.5F;
                bubble3.transform.localScale = new Vector3(1F, 1F, 0F)*Time.time;
            }
            if (a[3] == 1)
            {
                bubble4.transform.localScale = new Vector3(1F, 1F, 0F)*Time.time;
            }
            if (a[4] == 1)
            {
                bubble5.transform.localScale = new Vector3(1F, 1F, 0F)*Time.time;
            }
            if (a[5] == 1)
            {
                bubble6.transform.localScale = new Vector3(1F, 1F, 0F)*Time.time;
            }
        }
    }
