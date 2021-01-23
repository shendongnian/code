    class Program
    {
        const int MAX_RAY_DEPTH = 8;
        const float FAR = 100000000;
        public static void Main(string[] args)
        {
            Sphere[] spheres = new Sphere[7];
            spheres[0] = new Sphere(new Vec3f( 0.0f, -10004, -20), 10000, new Vec3f(0.20f, 0.20f, 0.20f), 0, 0.0f);
            spheres[1] = new Sphere(new Vec3f( 0.0f,      0, -20),     4, new Vec3f(1.00f, 0.32f, 0.36f), 1, 0.5f);
            spheres[2] = new Sphere(new Vec3f( 5.0f,     -1, -15),     2, new Vec3f(0.90f, 0.76f, 0.46f), 1, 0.0f);
            spheres[3] = new Sphere(new Vec3f( 5.0f,      0, -25),     3, new Vec3f(0.65f, 0.77f, 0.97f), 1, 0.0f);
            spheres[4] = new Sphere(new Vec3f(-5.5f,      0, -15),     3, new Vec3f(0.90f, 0.90f, 0.90f), 1, 0.0f);
            spheres[5] = new Sphere(new Vec3f(   2f,      2, -30),     4, new Vec3f(0.53f, 0.38f, 0.91f), 1, 0.7f);
            spheres[6] = new Sphere(new Vec3f(    0,     20, -30),     3, new Vec3f(0.00f, 0.00f, 0.00f), 0, 0.0f, new Vec3f(3));
            Render(spheres);
        }
        public struct Collision
        {
            public readonly float t0, t1;
            public readonly bool collide;
            public Collision(bool col, float tt0, float tt1)
            {
                t0 = tt0 < 0 ? tt1 : tt0;
                t1 = tt1;
                collide = col;
            }
        }
        public struct Vec3f
        {
            public readonly float x, y, z;
            public Vec3f(float v) { x = y = z = v; }
            public Vec3f(float xx, float yy, float zz) { x = xx; y = yy; z = zz; }
            public Vec3f normalize()
            {
                float nor2 = length2();
                if (nor2 > 0)
                {
                    float invNor = 1 / (float)Math.Sqrt(nor2);
                    return new Vec3f(x * invNor, y * invNor, z * invNor);
                }
                return this;
            }
            public static Vec3f operator *(Vec3f l, Vec3f r)
            {
                return new Vec3f(l.x * r.x, l.y * r.y, l.z * r.z);
            }
            public static Vec3f operator *(Vec3f l, float r)
            {
                return new Vec3f(l.x * r, l.y * r, l.z * r);
            }
            public float dot(Vec3f v)
            {
                return x * v.x + y * v.y + z * v.z;
            }
            public static Vec3f operator -(Vec3f l, Vec3f r)
            {
                return new Vec3f(l.x - r.x, l.y - r.y, l.z - r.z);
            }
            public static Vec3f operator +(Vec3f l, Vec3f r)
            {
                return new Vec3f(l.x + r.x, l.y + r.y, l.z + r.z);
            }
            public static Vec3f operator -(Vec3f v)
            {
                return new Vec3f(-v.x, -v.y, -v.z);
            }
            public float length2()
            {
                return x * x + y * y + z * z;
            }
            public float length()
            {
                return (float)Math.Sqrt(length2());
            }
        }
        public class Sphere
        {
            public readonly Vec3f center, surfaceColor, emissionColor;
            public readonly float radius, radius2;
            public readonly float transparency, reflection;
            public Sphere(Vec3f c, float r, Vec3f sc, float refl = 0, float transp = 0, Vec3f? ec = null)
            {
                center = c; radius = r; radius2 = r * r;
                surfaceColor = sc; emissionColor = (ec == null) ? new Vec3f() : ec.Value;
                transparency = transp; reflection = refl;
            }
            public Collision intersect(Vec3f rayorig, Vec3f raydir)
            {
                Vec3f l = center - rayorig;
                float tca = l.dot(raydir);
                if (tca < 0) { return new Collision(); }
                float d2 = l.dot(l) - tca * tca;
                if (d2 > radius2) { return new Collision(); }
                float thc = (float)Math.Sqrt(radius2 - d2);
                return new Collision(true, tca - thc, tca + thc);
            }
        }
        public static float mix(float a, float b, float mix)
        {
            return b * mix + a * (1 - mix);
        }
        public static Vec3f trace(Vec3f rayorig, Vec3f raydir, Sphere[] spheres, int depth)
        {
            float tnear = FAR;
            Sphere sphere = null;
            for (int i = 0; i < spheres.Length; i++)
            {
                Collision coll = spheres[i].intersect(rayorig, raydir);
                if (coll.collide && coll.t0 < tnear)
                {
                    tnear = coll.t0;
                    sphere = spheres[i];
                }
            }
            if (sphere == null) { return new Vec3f(2); }
            Vec3f surfaceColor = new Vec3f();
            Vec3f phit = rayorig + raydir * tnear;
            Vec3f nhit = (phit - sphere.center).normalize();
            float bias = 1e-4f;
            bool inside = false;
            if (raydir.dot(nhit) > 0) { nhit = -nhit; inside = true; }
            if ((sphere.transparency > 0 || sphere.reflection > 0) && depth < MAX_RAY_DEPTH)
            {
                float facingratio = -raydir.dot(nhit);
                float fresneleffect = mix((float)Math.Pow(1 - facingratio, 3), 1, 0.1f);
                Vec3f refldir = (raydir - nhit * 2 * raydir.dot(nhit)).normalize();
                Vec3f reflection = trace(phit + nhit * bias, refldir, spheres, depth + 1);
                Vec3f refraction = new Vec3f();
                if (sphere.transparency > 0)
                {
                    float ior = 1.1f; float eta = inside ? ior : 1 / ior;
                    float cosi = -nhit.dot(raydir);
                    float k = 1 - eta * eta * (1 - cosi * cosi);
                    Vec3f refrdir = (raydir * eta + nhit * (eta * cosi - (float)Math.Sqrt(k))).normalize();
                    refraction = trace(phit - nhit * bias, refrdir, spheres, depth + 1);
                }
                surfaceColor = (
                    reflection * fresneleffect + 
                    refraction * (1 - fresneleffect) * sphere.transparency) * sphere.surfaceColor;
            }
            else
            {
                for (int i = 0; i < spheres.Length; i++)
                {
                    if (spheres[i].emissionColor.x > 0)
                    {
                        Vec3f transmission = new Vec3f(1);
                        Vec3f lightDirection = (spheres[i].center - phit).normalize();
                        for (int j = 0; j < spheres.Length; j++)
                        {
                            if (i != j)
                            {
                                Collision jcoll = spheres[j].intersect(phit + nhit * bias, lightDirection);
                                if (jcoll.collide)
                                {
                                    transmission = new Vec3f();
                                    break;
                                }
                            }
                        }
                        surfaceColor += sphere.surfaceColor * transmission *
                            Math.Max(0, nhit.dot(lightDirection)) * spheres[i].emissionColor;
                    }
                }
            }
            return surfaceColor + sphere.emissionColor;
        }
        public static void Render(Sphere[] spheres)
        {
            int width = 800, height = 600;
            Vec3f[] image = new Vec3f[width * height];
            int pixelIndex = 0;
            float invWidth = 1f / width, invHeight = 1f / height;
            float fov = 30, aspectratio = (float)width / height;
            float angle = (float)Math.Tan(Math.PI * 0.5 * fov / 180);
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++, pixelIndex++)
                {
                    float xx = (2 * ((x + 0.5f) * invWidth) - 1) * angle * aspectratio;
                    float yy = (1 - 2 * ((y + 0.5f) * invHeight)) * angle;
                    Vec3f raydir = new Vec3f(xx, yy, -1).normalize();
                    image[pixelIndex] = trace(new Vec3f(), raydir, spheres, 0);
                }
            }
            StringWriter writer = new StringWriter();
            WriteableBitmap bitmap = new WriteableBitmap(width, height, 96, 96, PixelFormats.Rgb24, null);
            bitmap.Lock();
            unsafe
            {
                byte* buffer = (byte*)bitmap.BackBuffer;
                {
                    writer.Write("P3 800 600 255\r\n");
                    for (int y = 0; y < height; y++)
                    {
                        for (int x = 0; x < width; ++x)
                        {
                            if (x > 0) { writer.Write(" "); }
                            Vec3f pixel = GetColor(image[y * width + x]);
                            writer.Write(pixel.x + " " + pixel.y + " " + pixel.z);
                            int bufferOffset = y * bitmap.BackBufferStride + x * 3;
                            buffer[bufferOffset] = (byte)pixel.x;
                            buffer[bufferOffset + 1] = (byte)pixel.y;
                            buffer[bufferOffset + 2] = (byte)pixel.z;
                        }
                        writer.WriteLine();
                    }
                }
            }
            bitmap.Unlock();
            var encoder = new PngBitmapEncoder();
            using (Stream stream = File.OpenWrite("temp.png"))
            {
                encoder.Frames.Add(BitmapFrame.Create(bitmap));
                encoder.Save(stream);
            }
            string result = writer.ToString();
        }
        public static Vec3f GetColor(Vec3f col)
        {
            return new Vec3f(Math.Min(1, col.x) * 255, Math.Min(1, col.y) * 255, Math.Min(1, col.z) * 255);
        }
    }
