    using System;
    using Android.Content;
    using Android.Database;
    using Android.OS;
    using Android.Provider;
    using Java.IO;
    namespace <YourNameSpace>
    {
    public class Uris
    {
        private static String GetFileName(Context context, Android.Net.Uri uri)
        {
            String result = null;
            if (uri.Scheme.Equals("content"))
            {
                ICursor cursor = context.ContentResolver.Query(uri, null, null, null, null);
                try
                {
                    if (cursor != null && cursor.MoveToFirst())
                    {
                        result = cursor.GetString(cursor.GetColumnIndex(OpenableColumns.DisplayName));
                    }
                }
                finally
                {
                    cursor.Close();
                }
            }
            if (result == null)
            {
                result = uri.Path;
                int cut = result.LastIndexOf('/');
                if (cut != -1)
                {
                    result = result.Substring(cut + 1);
                }
            }
            return result;
        }
        //    @TargetApi(Build.VERSION_CODES.KITKAT)
        public static String GetPath(Context context, Android.Net.Uri uri)
        {
            bool isKitKat = Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.Kitkat; //Build.VERSION_CODES.Kitkat;
            // DocumentProvider
            if (isKitKat && DocumentsContract.IsDocumentUri(context, uri))
            {
                // ExternalStorageProvider
                if (IsExternalStorageDocument(uri))
                {
                    String docId = DocumentsContract.GetDocumentId(uri);
                    String[] split = docId.Split(":");
                    String type = split[0];
                    if ("primary".Equals(type, StringComparison.InvariantCultureIgnoreCase)) //equalsIgnoreCase
                    {
                        return Android.OS.Environment.GetExternalStoragePublicDirectory(type) + "/" + split[1];
                    }
                }
                // DownloadsProvider
                else if (IsDownloadsDocument(uri))
                {
                    /*
                                final String id = DocumentsContract.getDocumentId(uri);
                                final Uri contentUri = ContentUris.withAppendedId(
                                        Uri.parse("content://<span id=\"IL_AD1\" class=\"IL_AD\">downloads</span>/public_downloads"), Long.valueOf(id));
                                return getDataColumn(context, contentUri, null, null);
                    */
                    String fileName = GetFileName(context, uri);
                    File downFile = new File(Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryDownloads), "/" + fileName);
                    return downFile.AbsolutePath;
                }
                // MediaProvider
                else if (IsMediaDocument(uri))
                {
                    String docId = DocumentsContract.GetDocumentId(uri);
                    String[] split = docId.Split(":");
                    String type = split[0];
                    Android.Net.Uri contentUri = null;
                    if ("image".Equals(type))
                    {
                        contentUri = MediaStore.Images.Media.ExternalContentUri;
                    }
                    else if ("video".Equals(type))
                    {
                        contentUri = MediaStore.Video.Media.ExternalContentUri;
                    }
                    else if ("audio".Equals(type))
                    {
                        contentUri = MediaStore.Audio.Media.ExternalContentUri;
                    }
                    String selection = "_id=?";
                    String[] selectionArgs = new String[] {
                    split[1]
            };
                    return GetDataColumn(context, contentUri, selection, selectionArgs);
                }
            }
            // MediaStore (and general)
            else if ("content".Equals(uri.Scheme, StringComparison.InvariantCultureIgnoreCase))
            {
                // Return the remote address
                if (IsGooglePhotosUri(uri))
                    return uri.LastPathSegment;
                return GetDataColumn(context, uri, null, null);
            }
            // File
            else if ("file".Equals(uri.Scheme, StringComparison.InvariantCultureIgnoreCase))
            {
                return uri.Path;
            }
            return null;
        }
        /**
         * Get the value of the data column for this Uri. This is useful for
         * MediaStore Uris, and other file-based ContentProviders.
         *
         * @param context The context.
         * @param uri The Uri to query.
         * @param selection (Optional) Filter used in the query.
         * @param selectionArgs (Optional) Selection arguments used in the query.
         * @return The value of the _data column, which is typically a file path.
         */
        public static String GetDataColumn(Context context, Android.Net.Uri uri, String selection,
                                           String[] selectionArgs)
        {
            ICursor cursor = null;
            String column = "_data";
            String[] projection = {
                column
            };
            try
            {
                cursor = context.ContentResolver.Query(uri, projection, selection, selectionArgs,
                        null);
                if (cursor != null && cursor.MoveToFirst())
                {
                    int index = cursor.GetColumnIndexOrThrow(column);
                    return cursor.GetString(index);
                }
            }
            finally
            {
                if (cursor != null)
                    cursor.Close();
            }
            return null;
        }
        /**
         * @param uri The Uri to check.
         * @return Whether the Uri authority is ExternalStorageProvider.
         */
        public
        static bool IsExternalStorageDocument(Android.Net.Uri uri)
        {
            return "com.android.externalstorage.documents".Equals(uri.Authority);
        }
        /**
         * @param uri The Uri to check.
         * @return Whether the Uri authority is DownloadsProvider.
         */
        public static bool IsDownloadsDocument(Android.Net.Uri uri)
        {
            return "com.android.providers.downloads.documents".Equals(uri.Authority);
        }
        /**
         * @param uri The Uri to check.
         * @return Whether the Uri authority is MediaProvider.
         */
        public static bool IsMediaDocument(Android.Net.Uri uri)
        {
            return "com.android.providers.media.documents".Equals(uri.Authority);
        }
        /**
         * @param uri The Uri to check.
         * @return Whether the Uri authority is Google <span id="IL_AD8" class="IL_AD">Photos</span>.
         */
        public static bool IsGooglePhotosUri(Android.Net.Uri uri)
        {
            return "com.google.android.apps.photos.content".Equals(uri.Authority);
        }
    }
    }
