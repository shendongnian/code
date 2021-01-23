    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    [RequireComponent(typeof(PhotonView))]
    public class cube : Photon.MonoBehaviour
    {
        [SerializeField]
        public int x;
        [SerializeField]
        public int y;
        [SerializeField]
        public int z;
        [SerializeField]
        public int value;
        void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
        {
            if (stream.isWriting)
            {
                stream.SendNext(x);
                stream.SendNext(y);
                stream.SendNext(z);
            }
            else
            {
                x = (int)stream.ReceiveNext();
                y = (int)stream.ReceiveNext();
                z = (int)stream.ReceiveNext();
            }
        }
    }
    
