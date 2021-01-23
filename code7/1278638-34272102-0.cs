    using UnityEngine;
    using System;
    public class Queue3Test : MonoBehaviour {
        private string paraString = "This is not the end of the line. This is only the beginning. It cannot get much worse.";
        private string[] words;
        private int counter = 0;
        private void Start()
        {
            InitializeParaString();
        }
        private void OnMouseDown()
        {
            ShowNextWord();
        }
        private void InitializeParaString()
        {
            counter = 0;
            words = paraString.Split(new[] { '.', ' ' }, StringSplitOptions.RemoveEmptyEntries);
        }
        private void ShowNextWord()
        {
            if (counter < words.Length)
            {
                print(words[counter]);
                counter++;
            }
        }
    }
