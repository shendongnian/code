    using UnityEngine;
    using System.Collections;
    public class Audio : MonoBehaviour
    {
		public void PlaySoundOnce (AudioClip audioClip)
		{
				StartCoroutine (PlaySoundCoroutine (audioClip));
		}
		IEnumerator PlaySoundCoroutine (AudioClip audioClip)
		{
				audio.PlayOneShot (audioClip);
				yield return new WaitForSeconds (audioClip.length);
				Destroy (gameObject);
		}
		public void PlaySoundLoop (AudioClip audioClip)
		{
				audio.clip = audioClip;
				audio.loop = true;
				audio.Play ();
		}
		public void StopSound ()
		{
				audio.Stop ();
				Destroy (gameObject);
		}
    }
