    using UnityEngine;
    using System.Collections;
    using System.Collections.Generic;
    public class AudioManager : MonoBehaviour
    {
		public AudioClip[] audioSources;
		public GameObject audioPrefabSource;
		public Dictionary<string,AudioClip> audioClips;
		static GameObject audioPrefab;
		static GameObject instance;
		static AudioSource musicPlayer;
		public static AudioManager audioManager;
		Dictionary<string,Audio> aliveSounds;
		AudioListener al;
		void Awake ()
		{
				audioManager = this;
				al = GetComponent<AudioListener> ();
				audioClips = new Dictionary<string, AudioClip> ();
				foreach (AudioClip a in audioSources) {
						audioClips.Add (a.name, a);
				}
				instance = this.gameObject;
				audioPrefab = audioPrefabSource;
				musicPlayer = audio;
				aliveSounds = new Dictionary<string, Audio> ();
				//DontDestroyOnLoad(gameObject);
		}
		void Update ()
		{
				if (!GameSetting.hasMusic) {
						musicPlayer.Pause ();
				} else {
						if (!musicPlayer.isPlaying) {
								musicPlayer.Play ();
						}
				}
				if (!GameSetting.hasSound && aliveSounds.Count > 0) {
						foreach (Audio a in aliveSounds.Values) {
								a.StopSound ();
						}
						aliveSounds.Clear ();
				}
				if (!al.enabled) {
						al.enabled = true;
				}
		}
		public static void PlaySoundOnce (string name)
		{
				if (!GameSetting.hasSound) {
						return;
				}
				if (!audioManager.audioClips.ContainsKey (name)) {
						return;
				}
				GameObject go = GameObject.Instantiate (audioPrefab) as GameObject;
				go.transform.parent = instance.transform;
				Audio a = go.GetComponent<Audio> ();
				a.PlaySoundOnce (audioManager.audioClips [name]);
		}
		
		public static void PlayMusic (string name)
		{
				if (!GameSetting.hasMusic) {
						return;
				}
				if (musicPlayer.clip == null || musicPlayer.clip.name != name) {
						//		musicPlayer.clip = audioManager.audioClips [name];
						musicPlayer.clip = Resources.Load ("Audio/" + name, typeof(AudioClip)) as AudioClip;
						musicPlayer.Stop ();
						musicPlayer.loop = true;
						musicPlayer.Play ();
				} else {
						musicPlayer.loop = true;
						musicPlayer.Play ();
				}
			
		}
    }
