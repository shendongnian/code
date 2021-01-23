    public class Param
    {
        public string camera_clock { get; set; }
        public string video_standard { get; set; }
        public string app_status { get; set; }
        public string stream_out_type { get; set; }
        public string save_low_resolution_clip { get; set; }
        public string video_resolution { get; set; }
        public string video_stamp { get; set; }
        public string video_quality { get; set; }
        public string timelapse_video { get; set; }
        public string photo_size { get; set; }
        public string photo_stamp { get; set; }
        public string photo_quality { get; set; }
        public string timelapse_photo { get; set; }
        public string selfie_photo { get; set; }
        public string burst_photo { get; set; }
        public string autoshoot_photo { get; set; }
        public string loop_record { get; set; }
        public string motion_detec_video { get; set; }
        public string status_led_switch { get; set; }
        public string wifi_led_switch { get; set; }
        public string osd_switch { get; set; }
        public string cardvr_switch { get; set; }
        public string delay_pwroff { get; set; }
        public string rotate_image { get; set; }
        public string mic_vol { get; set; }
        public string language { get; set; }
        public string date_disp_fmt { get; set; }
        public string auto_bkl_off { get; set; }
        public string auto_pwr_off { get; set; }
        public string light_freq { get; set; }
        public string meter_mode { get; set; }
        public string buzzer { get; set; }
    }
    public class RootObject
    {
        public int rval { get; set; }
        public int msg_id { get; set; }
        public Param param { get; set; }
    }
